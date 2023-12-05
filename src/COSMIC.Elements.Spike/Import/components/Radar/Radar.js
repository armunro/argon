export default {
    props: {
        width: Number,
        height: Number,
        plannedTasks: Array,
        unplannedTasks: Array
    },
    data (){
        return {
            
        }
    },
    methods: {
        
    },
    mounted() {
        
    },
    template: `
    <div class="fp-radar-container" :style="{width: width, height: height}" >
        <fpradarbackgroundlayer :width="width" :height="height"></fpradarbackgroundlayer>
        <fpradarrangerlayer :width="width" :height="height"></fpradarrangerlayer>
        <fpradarsymbollayer :width="width" :height="height" :planned-tasks="plannedTasks" :unplanned-tasks="unplannedTasks"></fpradarsymbollayer>
    </div>
  `
}
