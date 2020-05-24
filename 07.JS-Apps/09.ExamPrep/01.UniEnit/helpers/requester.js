const requster = function() {

    const baseUrl = 'https://baas.kinvey.com/';

    const get = function(url, headers) {
        url = baseUrl + url;
        headers['method'] = 'get';

        return makeRequest(url, headers);
    }

    const post = function(url, headers) {
        url = baseUrl + url;
        headers['method'] = 'post';

        return makeRequest(url, headers);
    }
    
    const put = function(url, headers) {
        url = baseUrl + url;
        headers['method'] = 'put';

        return makeRequest(url, headers);
    }
    
    const del = function(url, headers) {
        
        url = baseUrl + url;
        headers['method'] = 'delete';

        return makeRequest(url, headers);
    }

    const makeRequest = function(url, headers) {

        return fetch(url, headers);
    }

    return {
        get,
        post,
        put,
        del
    }
}();