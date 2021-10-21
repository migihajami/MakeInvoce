﻿namespace MakeInoice.Common.ViewModels
{
    /// <summary>
    /// Contractor View Model
    /// </summary>
    /// <author>Alexey Bubley</author>
    /// <date>2021-10-18</date>
    /// <seealso cref="MakeInoice.Common.ViewModels.CompanyViewModel" />
    public class ContractorViewModel : CompanyViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}