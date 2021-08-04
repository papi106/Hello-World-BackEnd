// <copyright file="ErrorViewModel.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}