class JetstreamApi {

    constructor(apiBase, token) {
        this.apiBase = apiBase;
        this.token = token;
        this.rxCount = 0;
        this.txCount = 0;
        this.latency = 0;
    }

    buildRequest(method, body, anonymous) {
        let init = {
            method: method,
            headers: {}
        }
        if (!anonymous) {
            init.withCredentials = true;
            init.credentials = "include";
            init.headers.Authorization = `Bearer ${this.token}`;
            init.headers['Content-Type'] = 'application/json';
        }
        return init;
    }

    getStatus() {
        this.txCount++;
        let sendDate = (new Date()).getTime();
        return fetch(`${this.apiBase}/status/`, this.buildRequest("GET")
        ).then(response => {
            this.rxCount++;
            var receiveDate = (new Date()).getTime();
            this.latency = receiveDate - sendDate
            return response;
        });
    }

    getToken(ident, secret) {
        this.txCount++;
        return fetch(`${this.apiBase}/Identity/Token`,
            this.buildRequest("POST", JSON.stringify({Principal: ident, Secret: secret})))
            .then(response => {
                this.rxCount++;
                return response.json()
            });
    }


    getObjects(kindId) {
        this.txCount++;
        return fetch(`${this.apiBase}/Kind/${kindId}/Objects`, this.buildRequest("GET"))
            .then(response => {
                this.rxCount++;
                return response.json()
            }).then(json => {
                return json;
            });
    }

    getObject(objectId) {
        this.txCount++;
        return fetch(`${this.apiBase}/Object/${objectId}`, this.buildRequest("GET"))
            .then(response => {
                this.rxCount++;
                return response.json()
            }).then(json => {
                return json;
            });
    }

    editObject(objectId, contents) {
        this.txCount++;
        return fetch(`${this.apiBase}/Object/${objectId}`, this.buildRequest("PUT", contents))
            .then(response => {
                this.rxCount++;
                return response.json()
            }).then(json => {
                return json;
            });
    }

    createObject(kind, contents) {
        this.txCount++;
        return fetch(`${this.apiBase}/Object/${kind}`, this.buildRequest("POST", contents))
            .then(response => {
                this.rxCount++;
                return response.json()
            });
    }

    deleteObject(objectId) {
        this.txCount++;
        return fetch(`${this.apiBase}/Object/${objectId}`, this.buildRequest("DELETE"))
            .then(response => {
                this.rxCount++;
                return response.json()
            });
    }

    deleteKind(kindId) {
        this.txCount++;
        return fetch(`${this.apiBase}/Kind/${kindId}`, this.buildRequest("DELETE"))
            .then(response => {
                this.rxCount++;
                return response.text()
            });
    }

    getKinds() {
        this.txCount++;

        return fetch(`${this.apiBase}/Kind`, this.buildRequest("GET"))
            .then(response => {
                this.rxCount++;
                return response.json()
            });
    }

    getKindSummary() {
        this.txCount++;

        return fetch(`${this.apiBase}/Kind/Summary`, this.buildRequest("GET"))
            .then(response => {
                this.rxCount++;
                return response.json()
            });
    }


    createKind(kind) {
        this.txCount++;

        return fetch(`${this.apiBase}/Kind/${kind}`, this.buildRequest("POST"))
            .then(response => {
                this.rxCount++;
                return response.json()
            });
    }


    getTasks() {
        this.txCount++;
        return fetch(`${this.apiBase}/Task`, this.buildRequest("GET"))
            .then(response => {
            this.rxCount++;
            return response.json()
        });
    }
}