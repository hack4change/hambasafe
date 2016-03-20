starterServices.service('EventFactory', ['$http', 'config',
    function ($http, config) {
      return {
        getAllEvents: function(id){
          return $http.get(config.baseServiceURL + '/v1/events', config)
        },
        getEvent: function(id){
          return $http.get(config.baseServiceURL + '/v1/event?id='+id, config)
          .then(function success(result){
c
          }, function error(err){

          })
        }
      };
    }
]);
