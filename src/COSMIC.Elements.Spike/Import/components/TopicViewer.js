import Helpers from "./Helpers.js";
export default {
    props: {
        kinds: Object,
        api: Object
    },
    data (){
        return {
            displayFilter: '',
            editing: {
                kind: {
                    id: '',
                    instance:null
                }
            },
        }
    },
    methods: {
        editKind: function (kind) {
            this.editing.kind.id = kind.id;
            this.editing.kind.instance = kind;
        },
        clearKind: function () {
            this.editing.kind.id = '';
            this.editing.kind.instance = {};
        },
        createKind: function (kind) {
            this.api.createKind(this.editing.kind.id)
                .then(x=> this.$emit("kind_created"));
            
        },
        deleteKind: function () {
            this.api.deleteKind(this.editing.kind.id)
                .then(x=>   this.$emit("kind_deleted"));
        },
        browseKind : function (kindId){
            this.$emit("browse_kind", kindId)            
        }
    },
    mounted() {
       
    },
    template: `
    <div class="p-0 m-0 border-0">
    <div class="input-group  mb-2">
            <span class="input-group-text" style="width:7rem">ENTRY</span>
            <input id="topicEditorInput" v-model="editing.kind.id"
                   aria-describedby="getObjectButtons"
                   class="form-control bg-black me-2 "
                   name="topicInput" type="text">
            <button id="deleteTopicButton" class="btn me-2   btn-outline-danger"

                    type="button" @click="deleteKind">DELETE
            </button>
            <button id="clearTopicButton" class="btn me-2 btn-outline-info  "
                    type="button" @click="clearKind" >CLEAR
            </button>

            <button class="btn btn-outline-warning  "
                    @click="createKind()"
                    type="button"
                   >EXEC
            </button>
        </div>
        <table class="table fp-data table-borderless ">
            <thead>
            <tr class="">
                <th scope="col">Kind</th>
                <th class="text-center" scope="col">DATA</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="kind in kinds">
                <td class="fp-editable" @click="editKind(kind)">
                    {{ kind.name }}
                </td>
                <td class="fp-navable text-center"
                    @click="browseKind(kind.id)">
                    {{ kind.objectCount }}&nbsp;<span
                        style="cursor: pointer"></span></td>
                
            </tr>
            </tbody>
        </table>
    </div>
  `
}
