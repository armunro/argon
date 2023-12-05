export default {
    props: {
       tasks: Array
    },
    template: `
 <table class="table table-borderless">
    <thead>
    <tr >
        <th scope="col">Name</th>
        <th scope="col">I-TYPE</th>
        <th scope="col">C-TYPE</th>
    </tr>
    </thead>
    <tbody>
       <tr v-for="task in tasks">
        <td>{{task.title}}</td>
        <td>{{task.instructionType}}</td>
        <td>{{task.completionType}}</td>
       </tr>
    </tbody>
</table>
  `
}