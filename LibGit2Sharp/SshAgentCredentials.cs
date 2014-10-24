using System;
using LibGit2Sharp.Core;

namespace LibGit2Sharp
{
    /// <summary>
    /// Class that holds ssh agent credentials for remote repository access.
    /// </summary>
    public sealed class SshAgentCredentials : Credentials
    {
        /// <summary>
        /// Callback to acquire a credential object.
        /// </summary>
        /// <param name="cred">The newly created credential object.</param>
        /// <param name="url">The resource for which we are demanding a credential.</param>
        /// <param name="usernameFromUrl">The username that was embedded in a "user@host"</param>
        /// <param name="types">A bitmask stating which cred types are OK to return.</param>
        /// <param name="payload">The payload provided when specifying this callback.</param>
        /// <returns>0 for success, &lt; 0 to indicate an error, &gt; 0 to indicate no credential was acquired.</returns>
        protected internal override int GitCredentialHandler(out IntPtr cred, IntPtr url, IntPtr usernameFromUrl, GitCredentialType types, IntPtr payload)
        {
            if (Username == null)
            {
                throw new InvalidOperationException("SshAgentCredentials contains a null Username.");
            }

            return NativeMethods.git_cred_ssh_key_from_agent(out cred, Username);
        }

        /// <summary>
        /// Username for SSH authentication.
        /// </summary>
        public string Username { get; set; }
    }
}

