﻿using System;
using System.Diagnostics;
using ConDep.Dsl.Operations.WebDeploy.Model;

namespace ConDep.Dsl.Specs.Executors
{
    public class RunCmdExecutor : ConDepOperation, IExecuteWebDeploy
    {
        private readonly string _command;

        public RunCmdExecutor(string command)
        {
            _command = command;
        }

        protected override void OnMessage(object sender, WebDeployMessageEventArgs e)
        {
            Trace.TraceInformation(e.Message);
        }

        protected override void OnErrorMessage(object sender, WebDeployMessageEventArgs e)
        {
            Trace.TraceError(e.Message);
        }

        public WebDeploymentStatus Execute()
        {
            return Setup(setup => setup.Sync(s =>
                                                 {
                                                     s.WithConfiguration(c => c.DoNotAutoDeployAgent());
                                                     s.From.LocalHost();
                                                     s.Using.RunCmd(_command);
                                                     s.To.LocalHost();
                                                 }
                                      ));

        }

        public WebDeploymentStatus ExecuteFromPackage()
        {
            throw new NotImplementedException();
        }
    }
}