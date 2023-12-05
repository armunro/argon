import {createApp} from 'https://unpkg.com/vue@3/dist/vue.esm-browser.js'
import FpRadar from "../components/Radar/Radar.js"
import FpRadarBackgroundLayer from "../components/Radar/Layers/RadarBackgroundLayer.js"
import FpRadarRangerLayer from "../components/Radar/Layers/RadarRangerLayer.js"
import FpRadarSymbolLayer from "../components/Radar/Layers/RadarSymbolLayer.js"


let app = createApp({
    data() {
        return {
            plannedTasks: [
                {
                    "Key": "J-1371",
                    "Source": "Jira",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T12:00:00.000Z",
                    "TargetEnd": "2023-09-16T13:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60


                },
                {
                    "Key": "J-1371",
                    "Source": "Jira",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "Progress": 30,
                    "Estimate": 60
                    
                    
                },
                {
                    "Key": "J-1299",
                    "Source": "Jira",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T14:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60
                },
                {
                    "Key": "J-1262",
                    "Source": "Jira",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T15:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60
                    
                },
                {
                    "Key": "15698504",
                    "Source": "Case",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T16:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60
                    
                },
                {
                    "Key": "14114681",
                    "Source": "Case",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T17:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60
                    
                },
                {
                    "Key": "13388161",
                    "Source": "Other",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T18:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60                  
                    
                },
                {
                    "Key": "13388161",
                    "Source": "Other",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T19:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60

                },
                {
                    "Key": "13388161",
                    "Source": "Other",
                    "Reporter": "",
                    "Assignee": "",
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T20:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60

                }
            ],
            unplannedTasks: [
            {
                "Key": "J-1371",
                "Source": "Jira",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T12:00:00.000Z",
                "Progress": 30,
                "Estimate": 60


            },
            {
                "Key": "J-1371",
                "Source": "Jira",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T13:00:00.000Z",
                "Progress": 30,
                "Estimate": 60


            },
            {
                "Key": "J-1299",
                "Source": "Jira",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T14:00:00.000Z",
                "Progress": 30,
                "Estimate": 60
            },
            {
                "Key": "J-1262",
                "Source": "Jira",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T15:00:00.000Z",
                "Progress": 30,
                "Estimate": 60

            },
            {
                "Key": "15698504",
                "Source": "Case",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T16:00:00.000Z",
                "Progress": 30,
                "Estimate": 60

            },
            {
                "Key": "14114681",
                "Source": "Case",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T17:00:00.000Z",
                "Progress": 30,
                "Estimate": 60

            },
            {
                "Key": "13388161",
                "Source": "Other",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T18:00:00.000Z",
                "Progress": 30,
                "Estimate": 60

            },
            {
                "Key": "13388161",
                "Source": "Other",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T19:00:00.000Z",
                "Progress": 30,
                "Estimate": 60

            },
            {
                "Key": "13388161",
                "Source": "Other",
                "Reporter": "",
                "Assignee": "",
                "Title": "",
                "Link": "",
                "TargetStart": "2023-09-16T20:00:00.000Z",
                "Progress": 30,
                "Estimate": 60

            }
        ]
            
        }
    },
    methods: {
        
    },
    mounted() {
        
    },
    watch: {}
});

app.component("fpradar",FpRadar);
app.component("fpradarbackgroundlayer",FpRadarBackgroundLayer);
app.component("fpradarrangerlayer",FpRadarRangerLayer);
app.component("fpradarsymbollayer",FpRadarSymbolLayer);
app = app.mount("#app");
