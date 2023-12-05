import Helpers from "./Helpers.js";

export default {
    data (){
        return {
            countdown: ''
        }
    },
    props: {
        timer: Object
    },
    methods:{
        formatCountdown(targetDate) {
            this.countdown = Helpers.formatCountdown(targetDate)
        }
    },
    mounted() {
        setInterval(() => this.formatCountdown(this.timer.contents.date))
    },
    template: `
   <div class="col-auto p-1 fp-advisable border-end " @click="$parent.adviseObject(timer)">
    <div class="row  g-0" style="">
      <div class="col ps-1 fp-label">{{ timer.contents.name }}</div>
      <div  class="col ps-1 fp-info text-end">T-</div>
    </div>
    <div class="row g-0" style="">
      <div class="col px-1 text-center ">{{ countdown }}</div>
    </div>
  </div>
  `
}
