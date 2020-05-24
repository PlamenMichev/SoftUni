const storage = function() {
    
    const appKey = 'kid_B1khLPnzB';
    const appSecret = '9c272906b5ab480f9a6a7558aa16fe56';

    const saveUser = function(data) {
        localStorage.setItem('userInfo', JSON.stringify(data));
        localStorage.setItem('authKey', JSON.stringify(data._kmd.authtoken));
    }

    const getData = function(key) {
        return localStorage.getItem(key);
    }

    const deleteUser = function() {
        localStorage.removeItem('userInfo');
        localStorage.removeItem('authToken');
    }

    return {
        saveUser,
        getData,
        deleteUser,
        appKey,
        appSecret
    }

}();