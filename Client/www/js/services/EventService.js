starterServices.service('EventService', ['$http', 'config',
    function ($http, config) {
      return {
        createEvent: function(data){
          return $http.get(config.baseServiceURL + '/v1/createevent', data, config)
        },
        getAllEvents: function(id){
          return $http.get(config.baseServiceURL + '/v1/events', config)
        },
        getEvent: function(id){
          return $http.get(config.baseServiceURL + '/v1/event?id='+id, config)
        },
        getEventTypes: function(){
          return $http.get(config.baseServiceURL + '/v1/event-types', config)
        },
        getEventByUser: function(id){
          return $http.get(config.baseServiceURL + '/v1/events-by-user', config)
        },
        getEventByAttendee: function(data){
          var param = Object.keys(data);
          return $http.get(config.baseServiceURL + '/v1/events-by-attendee?'+param+"="+data.param, config)
        },
        getEventBySuburb: function(data){
          var param = Object.keys(data);
          return $http.get(config.baseServiceURL + '/v1/events-by-suburb?'+param+"="+data.param, config)
        },
        getEventByCoords: function(latitude, longitude, radius){
          return $http.get(config.baseServiceURL + '/v1/events-by-coordinates?latitude='+latitude+'&longitude='+longitude+'&radius='+radius, config)
        }
      };
    }
]);
