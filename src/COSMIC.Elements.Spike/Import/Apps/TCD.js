import {createApp} from 'https://unpkg.com/vue@3/dist/vue.esm-browser.js'
import TcdCard from "../components/TCD/TcdCard.js"

let app = createApp({
    data() {
        return {
            plannedTasks: [
                {
                    "Key": "J-1371",
                    "Source": "Jira",
                    "Reporter": "",
                    "Assignee": "",
                    "Status": {},
                    "Title": "",
                    "Link": "",
                    "TargetStart": "2023-09-16T12:00:00.000Z",
                    "TargetEnd": "2023-09-16T13:00:00.000Z",
                    "Progress": 30,
                    "Estimate": 60,
                    "Priority": {"priority": "High", "color": "#ff0000"},
                    "Due": "2023-09-20T12:00:00.000Z"
                }
            ],

        }
    },
    methods: {
        getClickUpListTasks(listId) {
            let url = `https://api.clickup.com/api/v2/list/${listId}/task?archived=false&subtasks=true`;
            fetch(url, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'pk_10528269_N202FCQLRP5AEP5Q0GWNRVKCTRZJYTZZ'
                }
            }).then(response => response.json())
                .then((data) => {
                    console.log(data);
                    let tasks = this.mapTasks(data.tasks)
                    console.log(tasks);
                    this.plannedTasks = this.plannedTasks.concat(tasks);
                })
                .catch((error) => {
                    console.error('Error:', error);
                });
            
        },
        mapTasks(tasks) {
            let mappedTasks = [];
            for (let task of tasks) {
                mappedTasks.push({
                    "Key": task.id,
                    "Source": "ClickUp",
                    "Reporter": "",
                    "Assignee": "",
                    "Jira": task.custom_fields.find(field => field.name === "Jira"),
                    "Stellar": task.custom_fields.find(field => field.name === "Stellar"),
                    "Status": task.status,
                    "Title": task.name,
                    "Link": task.url,
                    "TargetStart": task.start_date,
                    "TargetEnd": parseInt(task.due_date),
                    "Progress": task.progress,
                    "Estimate": task.time_estimate,
                    "Priority": task.priority,
                    "Due": parseInt(task.due_date)
                });
            }
            return mappedTasks;
        },
        init(){
            this.getClickUpListTasks("901100931943");
            this.getClickUpListTasks("901100951115");
        }
    },
    mounted() {
        this.init();
    },
    watch: {}
});

app.component("fptcdcard", TcdCard);

app = app.mount("#app");
document.app = app;
