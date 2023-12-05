export default {
    props: {
        message: Object
    },    
    
    template: `
<div class="row fp-advisable h-25" @click="$parent.adviseObject(message)">
    <div class="col-12 p-1">
        <span class="fp-label">{{ message.contents.source }}</span> {{ message.contents.message }}
    </div>
</div>
  `
}
    