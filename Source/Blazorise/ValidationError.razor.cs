﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise
{
    public partial class ValidationError : BaseValidationResult
    {
        #region Members

        private bool tooltip;

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            ErrorText = ParentValidation?.Message;

            base.OnInitialized();
        }

        protected override void BuildClasses( ClassBuilder builder )
        {
            if ( !Tooltip )
                builder.Append( ClassProvider.ValidationError() );
            else
                builder.Append( ClassProvider.ValidationErrorTooltip() );

            base.BuildClasses( builder );
        }

        protected override void OnValidationStatusChanged( object sender, ValidationStatusChangedEventArgs eventArgs )
        {
            if ( eventArgs.Status == ValidationStatus.Error )
            {
                ErrorText = eventArgs.Message;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Custom error type that will override default content.
        /// </summary>
        protected string ErrorText { get; set; }

        /// <summary>
        /// Shows the tooltip instead of label.
        /// </summary>
        [Parameter]
        public bool Tooltip
        {
            get => tooltip;
            set
            {
                tooltip = value;

                DirtyClasses();
            }
        }

        #endregion
    }
}
