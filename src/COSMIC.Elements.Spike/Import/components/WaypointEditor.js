import Helpers from "./Helpers.js";

export default {
    props: {
        waypoint: Object
    },
    data() {
        return {
            data1: '',
            data2: ''
        }
    }, methods: {
        myFun() {
        }
    }, mounted() {
    },
    template: `  
  <form>
  <div class="mb-3">
    <label for="taskTitle" class="form-label">Task Title</label>
    <input type="text" :value="waypoint.contents.summary" class="form-control" id="taskTitle" placeholder="Enter task title" required>
  </div>
  <div class="mb-3">
    <label for="taskKey" class="form-label">Task Key</label>
    <input type="text" :value="waypoint.contents.key" class="form-control" id="taskKey" placeholder="Enter task key" required>
  </div>

  <div class="mb-3">
    <label for="dueDate" class="form-label">Due Date</label>
    <input type="date" :value="waypoint.contents.date" class="form-control" id="dueDate" required>
  </div>
  <button type="submit" class="btn btn-primary">Create Task</button>
</form>
    `
}