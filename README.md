# logicapps-perfmon
Tool to extract Azure Logic Apps performance metrics

# Usage
1. Build the solution
2. Configure all required settings in the app.config file.  Multiple sections are possible.
    - workflowname: the name of the logic app you want to monitor
    - resourcegroup: the name of the resource group in which the logic app is deployed
    - tenantid: the tenantid of your subscription
    - subscriptionid: the id of you subscription
    - clientid: the oAuth clientid to connect to the Azure rest API
    - clientSecret:  the oAuth client secret to connect to the Azure rest API
3. Run the tool from the commandline with the following arguments: `ReportGenerator.exe -i <name-of-config-section> -m <maximum-results:50> -d <output-dir>`
