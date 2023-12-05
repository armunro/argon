let symbols = {
    "Jira": {
        "cssClasses": "fa-brands fa-jira",
        "unicode": "\uf219"
    },
    "case": {
        "cssClasses": "fa fa-jira",
        "unicode": "\uf7d4"
    },
    "default": {
        "cssClasses": "fa fa-jira",
        "unicode": "\uf60b"
    }
}

function resolveSymbol(type)
{
    if (symbols[type])
        return symbols[type];
    else
        return symbols["default"];
}