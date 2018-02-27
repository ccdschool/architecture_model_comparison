using System;

namespace ioda.adapters.dialogs
{
    class Commandline
    {
        private readonly string[] _args;
        
        public Commandline(string[] args) { _args = args; }
        
        
        public void Determine_text_source(Action<string> onFile, Action onUser) {
            if (_args.Length > 0)
                onFile(_args[0]);
            else
                onUser();
        }
    }
}