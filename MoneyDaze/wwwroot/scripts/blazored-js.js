Blazor.registerFunction('blzrdJsSaveToLocalStorage', (identifier, data) => {
    localStorage.setItem(identifier, data); return true;
});

Blazor.registerFunction('blzrdJsGetFromLocalStorage', (identifier) => {
    return localStorage.getItem(identifier);
});

Blazor.registerFunction('blzrdJsRemoveFromLocalStorage', (identifier) => {
    localStorage.removeItem(identifier); return true;
});