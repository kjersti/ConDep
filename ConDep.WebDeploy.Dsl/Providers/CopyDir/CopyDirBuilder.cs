﻿namespace ConDep.WebDeploy.Dsl
{
	public class CopyDirBuilder : IProviderBuilder<CopyDirBuilder>
	{
		private readonly CopyDirProvider _copyDirProvider;

		public CopyDirBuilder(CopyDirProvider copyDirProvider)
		{
			_copyDirProvider = copyDirProvider;
		}

		public IProviderBuilder<CopyDirBuilder> SetRemotePathTo(string remotePath)
		{
			_copyDirProvider.DestinationPath = remotePath;
			return this;
		}
	}
}