import Helpers from "./Helpers.js";
export default {
    props: {
        calevent: Object
    },
    data (){
        return {
            displayStart: '',
            displayEnd: ''
        }
    },
    methods: {
        setDisplayDates()
        {
            let startDate = new Date( this.calevent.contents.startDate);
            let endDate = new Date( this.calevent.contents.endDate);
            
            this.displayStart = this.calevent.contents.startDate;
            this.displayEnd = this.calevent.contents.endDate;
            if((startDate.getFullYear() === endDate.getFullYear()) &&
                (startDate.getMonth() === endDate.getMonth()) &&
                (startDate.getDate() === endDate.getDate()))
            {
                this.displayEnd = `${Helpers.formatTime2(endDate.getHours())}:${Helpers.formatTime2(endDate.getMinutes())} `
            }
        }
    },
    mounted() {
        this.setDisplayDates();
    },
    template: `
<div class="row g-0 h-50 p-0 fp-advisable" @click="$parent.adviseObject(calevent)">
<div class="col p-0 m-0 ">
    <div class="row h-50  g-0 ">
        <div class="col p-1">{{ calevent.contents.name }}</div>
    </div>
    <div class="row g-0 h-50">
        <div class="col p-1">
            <span class="fp-info">{{ displayStart}}</span> 弄
            <span class="fp-info">{{displayEnd  }}</span>
        </div>
    </div>
</div>
</div>
  `
}
