using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Plugin
{
    // Plugin class to create a record in Dataverse
    public class CreateRecordPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Retrieve execution context
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Prevent infinite loops: Check if the plugin is already running in a loop
            if (context.Depth > 1) // Depth 1 means first execution, Depth > 1 means recursion
            {
                return; // Stop execution to prevent infinite loop
            }

            // Get the service factory and organization service
            var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            var service = serviceFactory.CreateOrganizationService(context.UserId);

            // Create a new record for the "almlab_test" table
            var record = new Entity("bzeira_plugin");

            // Set a value for the "almlab_new" column (assuming it's a text field)
            record["bzeira_plugin"] = "Example Value"; // Replace with actual logic

            // Create the record in Dataverse
            service.Create(record);
        }
    }
}
