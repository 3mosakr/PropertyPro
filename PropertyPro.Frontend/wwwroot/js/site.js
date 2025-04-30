window.localStorageHelper = {
    setAuthToken: function (token) {
        localStorage.setItem('authToken', token);
    },
    getAuthToken: function () {
        return localStorage.getItem('authToken');
    },
    removeAuthToken: function () {
        localStorage.removeItem('authToken');
    }
};

