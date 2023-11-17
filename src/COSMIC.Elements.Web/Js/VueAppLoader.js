class VueAppLoader {
    constructor(templateUri, data, methods, rootId, computed) {
        this.templateUri = templateUri;
        this.data = data;
        this.methods = methods;
        this.computed = computed;
        this.rootId = rootId;
        this.components = [];
        this.rootComp = null;

    }

    registerComponent(name, uri, component) {
        this.components.push({name: name, uri: uri, component: component});
    }

    load() {
        let appTemplateProm = fetch(this.templateUri).then(response => response.text());

        appTemplateProm.then(template => {
            this.vue = Vue.createApp({
                data: this.data,
                template: template,
                methods: this.methods,
                computed: this.computed
            });
            let compsProms = this.components.map(comp => fetch(comp.uri)
                .then(x => x.text())
                .then(compTemplate => {
                    comp.component.template = compTemplate;
                    this.vue.component(comp.name, comp.component)
                }))
            Promise.all(compsProms).then(x => {
                this.rootComp = this.vue.mount(this.rootId)
            })

        })

    }
}