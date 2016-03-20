starterServices.service('ProfileService', ['$http', 'config',
    function ($http, config) {
      var base = config.baseServiceURL + "/v1/";
      var profileKey = "profileKey";
      return {
        setProfile:function(id){
          localStorage.setItem(profileKey);
          return $http.post(base + 'create-user ', config)
         .then(function success(result) {

         }, function error(err) {

         });
        },
        getAll: function(id){
          return $http.get(base + 'users', config)
        },
        getById: function (id ) {
          var val = id || localStorage.getItem(profileKey);

          return $http.get(base + 'users?username=' + val, config);

        },
        getByUsername: function (id ) {
          var val = id || localStorage.getItem(profileKey);

          return $http.get(base + 'users?username=' + val, config);

        }
      };
    }
]);
