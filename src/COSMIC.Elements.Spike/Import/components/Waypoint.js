export default {
    props: {
       waypoint: Object
    },
    template: `
<div class="row align-middle g-0 h-25 fp-advisable ">
    <div class="row p-1" @click="$parent.adviseObject(waypoint)">
        <div class="col-11 pe-0">
            <span class="fp-alert">{{ waypoint.contents.key }}&nbsp;</span>
            <span class="fp-info">{{ waypoint.contents.summary }}</span>
        </div>
        <div class="col-1 p-0">
            {{ waypoint.contents.duration }}
        </div>
    </div>
</div>
  `
}
