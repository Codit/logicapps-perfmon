# Azure Logic Apps performance monitor
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

# Results
Currently, there is a CSV report generator, that outputs all action durations for every run:
  - Milliseconds are used as Unit of Measurement
  - The Headers names include the name of the action of the workflow and also the "lag" or time between the end of the previous action and the start of the new action

Number | WorkflowStart | WorkflowDuration | Lag_000 | Parse_JSON_Duration | Lag_001 | Start_Timer_Duration | Lag_002 | Compose_Duration | Lag_003 | PublishMessage_Duration | 
--- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
1 | 23/10/2018 10:09:53 | 932,8983 | 78,725 | 16,3114 | 46,2076 | 49,0403 | 13,4312 | 10,2358 | 5,415 | 701,15 | 
2 | 23/10/2018 10:09:53 | 1981,444 | 131,7012 | 11,4146 | 4,2417 | 27,7693 | 65,9571 | 10,1781 | 21,0727 | 1695,6048 | 
3 | 23/10/2018 10:09:53 | 949,655 | 86,791 | 11,2301 | 51,2889 | 52,7712 | 9,7003 | 9,9798 | 5,671 | 710,559 | 
4 | 23/10/2018 10:09:53 | 1977,9267 | 159,9262 | 10,3343 | 20,9216 | 22,3128 | 8,9601 | 12,1058 | 34,7491 | 1693,3761 | 
5 | 23/10/2018 10:09:53 | 853,8695 | 71,0683 | 11,3356 | 66,8245 | 24,8325 | 22,0169 | 19,2778 | 11,9951 | 612,1907 | 
