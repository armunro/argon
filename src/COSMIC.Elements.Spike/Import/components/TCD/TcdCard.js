
export default {
    data (){
        return {
        }
    },
    props: {
        task: Object
    },
    methods:{
        formatDate(date){
            return new Date(date).toLocaleDateString()
        }, 
        formatTime(date){
            return new Date(date).toLocaleTimeString()
        }
    },
    mounted() {

    },
    template: ` 
        <div class="row border-bottom ">
            <div class="col-3 border-end ">
                <div class="row">
                    <div class="col-12 m-1">
                        {{task.Key}}
                    </div>
                </div>
                <div class="row" v-if="task.Jira">
                    <div class="col-3 text-info m-1" >
                        JIRA
                    </div>
                    <div class="col-8 m-1">
                        {{task.Jira}}
                    </div>
                </div>
                <div class="row" v-if="task.Stellar">
                    <div class="col-3 text-info m-1" >
                        STLR
                    </div>
                    <div class="col-8"  >
                        {{task.Stellar}}
                    </div>
                </div>
            </div>
             <div class="col-2 border-end ">
                <div class="row" v-if="task.Status" >
                    <div class="col-4 text-success p-1">
                    STATUS
                    </div>
                    <div class="col p-1" :style="{ 'color': task.Status.color}">
                        {{task.Status.status}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4 p-1 text-success">
                        PRIORITY
                    </div>
                    <div class="col p-1" v-if="task.Priority" :style="{ color: task.Priority.color}">
                        {{task.Priority.priority}}
                    </div>
                </div>
            </div>
            <div class="col border-end" >
                <div class="row">
                    <div class="col-12 m-1">
                         {{task.Title}}
                    </div>
                </div>
            </div>
          <div class="col-4 ">
                <div class="row">
                    <div class="col-2 text-info">
                        START 
                    </div>
                      <div class="col-10 ">
                        {{formatDate(this.task.TargetStart)}}  {{formatTime(this.task.TargetStart)}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-2 text-info">
                        END 
                    </div>
                     <div class="col-10">
                        {{formatDate(this.task.Due)}} {{formatTime(this.task.TargetEnd)}}  
                    </div>
                </div>
                <div class="row ">
                    <div class="col- text-secondary">
                        EST {{task.Estimate}}
                    </div>
                </div>
            </div>
        </div>
                  
    `
}
