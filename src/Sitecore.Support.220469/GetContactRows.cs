using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.ListManagement.ContentSearch.Model;

namespace Sitecore.Support.ListManagement.ContentSearch.Pipelines.ExportContacts
{
  public class GetContactRows: Sitecore.ListManagement.ContentSearch.Pipelines.ExportContacts.GetContactRows
  {
    protected override IEnumerable<string> GetRow(IEnumerable<ContactData> contacts)
    {
      Assert.ArgumentNotNull(contacts, "contacts");
      string sep = this.Delimiter.ToString(CultureInfo.InvariantCulture);
      yield return string.Join(sep, "Identifier", "FirstName", "Surname", "Email");
      foreach (ContactData contact in contacts)
      {
        yield return string.Join(sep, "'"+contact.Identifier+"'", "'" + contact.FirstName + "'", "'" + contact.Surname + "'", "'" + contact.PreferredEmail + "'");
      }
    }
  }
}