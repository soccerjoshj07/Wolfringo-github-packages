﻿using System.Threading;
using System.Threading.Tasks;

namespace TehGM.Wolfringo.Commands
{
    /// <summary>Command requirement that checks if the bot has correct group permissions.</summary>
    /// <seealso cref="RequireBotGroupOwnerAttribute"/>
    /// <seealso cref="RequireBotGroupAdminAttribute"/>
    /// <seealso cref="RequireBotGroupModAttribute"/>
    public class RequireBotGroupPrivilegeAttribute : CommandRequirementAttribute
    {
        /// <summary>Flags of privileges that fulfill this requirement.</summary>
        /// <remarks>Only one of the privileges has to match. For example, Owner | Admin matches if bot is either Owner or Admin.</remarks>
        public WolfGroupCapabilities Privileges { get; }
        /// <summary>Whether this requirement should be ignored in private messages.</summary>
        /// <remarks><para>If this is set to true, <see cref="RunAsync(ICommandContext, CancellationToken)"/> will always return true for private messages.
        /// This is useful if the command should work normally in PM, even if in group it requires permissions.<br/>
        /// If this is set to false, <see cref="RunAsync(ICommandContext, CancellationToken)"/> will always return false for private messages.
        /// This will make command group-only.</para>
        /// <para>Defaults to false.</para></remarks>
        public bool IgnoreInPrivate { get; set; } = false;

        /// <summary>Creates a new instance of command group privilege requirement.</summary>
        /// <param name="privileges">Flags of privileges that fulfill this requirement.</param>
        /// <remarks>Only one of the privileges has to match. For example, Owner | Admin matches if bot is either Owner or Admin.</remarks>
        /// <seealso cref="Privileges"/>
        public RequireBotGroupPrivilegeAttribute(WolfGroupCapabilities privileges)
        {
            this.Privileges = privileges;
        }

        /// <inheritdoc/>
        public override Task<bool> RunAsync(ICommandContext context, CancellationToken cancellationToken = default)
        {
            if (!context.Message.IsGroupMessage)
                return Task.FromResult(IgnoreInPrivate);

            return RequireGroupPrivilegeAttribute.CheckPrivilegeAsync(context, context.Client.CurrentUserID.Value, this.Privileges, cancellationToken);
        }
    }
}