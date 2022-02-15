﻿using System;

namespace xFrame.Core.Modularity
{
    public interface ILoadingPhaseBuilder<TModule>
      where TModule : IModule
    {
        ILoadingPhaseBuilder<TModule> AddLoadingAction(object key,Action<ILoadingActionBuilder<TModule>> action);
        ILoadingPhaseBuilder<TModule> AddLoadingAction(ILoadingAction<TModule> loadingAction);
        ILoadingPhaseBuilder<TModule> Name(string name);
    }

}
