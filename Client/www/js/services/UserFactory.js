starterServices.factory('UserFactory', ['$http', 'config',
    function ($http, config) {
      return {
        getUser: function(id){
          return $http.get(config.baseServiceURL + '/v1/user', config).then(function success(){
          }, function error(){

          })
        },
        createUser: function(data){
          return $http.post(config.baseServiceURL + '/v1/user/create', data, config)
          .then(function success(result){

          }, function error(err){

          })
        }
      };
    }
]);
