starterServices.service('ProfileService', ['$http', 'config',
    function ($http, config) {
      var base = config.baseServiceURL + "/v1/";
      var profileKey = "profileKey";
      return {
        setProfile:function(id){
          localStorage.setItem(profileKey);
          return $http.post(base + 'createevent', config)
         .then(function success(result) {

         }, function error(err) {

         });
        },
        getAll: function(id){
          return $http.get(base + 'user', config)
        },
        get: function (id) {
          var val = id|| localStorage.getItem(profileKey);
          return $http.get(base + 'user?id=' + val, config)
          .then(function success(result){

          }, function error(err){

          })
        }
      };
    }
]);
