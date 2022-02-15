﻿using System;
using System.Collections.Generic;
using System.Text;

namespace xFrame.Core.Modularity
{
    public class LoadingPhase<TModule> : ILoadingPhase<TModule>
        where TModule : IModule
    {
        private List<ILoadingAction<TModule>> _loadingActions;        

        public object Key { get; }
        public IEnumerable<ILoadingAction<TModule>> LoadingActions => _loadingActions;

        public string Name { get; set; }

        public LoadingPhase(object key)
        {
            Key = key;
            Name = ToString();
        }

        public ILoadingPhase<TModule> AddAction(ILoadingAction<TModule> action)
        {
            _loadingActions.Add(action);
            return this;
        }
        public ILoadingPhase<TModule> AddAction(Action<ILoadingActionBuilder<TModule>> builder)
        {
            throw new NotImplementedException();
        }

        public void Run(TModule module)
        {
            foreach (var action in _loadingActions)
            {
                action.Execute(module);
            }
        }
    }
}
