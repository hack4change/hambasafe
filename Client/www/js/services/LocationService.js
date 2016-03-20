starterServices.service('LocationService', ['$http', 'config',
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
        getEventByUser: function(id){
          return $http.get(config.baseServiceURL + '/v1/eventsbyuser', config)
        },
        getEventByAttendee: function(data){
          var param = Object.keys(data);
          return $http.get(config.baseServiceURL + '/v1/eventsbyattendee?'+param+"="+data.param, config)
        },
        getEventBySuburb: function(data){
          var param = Object.keys(data);
          return $http.get(config.baseServiceURL + '/v1/eventsbysuburb?'+param+"="+data.param, config)
        },
        getEventByCoords: function(latitude, longitude, radius){
          return $http.get(config.baseServiceURL + '/v1/eventsbycoordinates?latitude='+latitude+'&longitude='+longitude+'&radius='+radius, config)
        }
      };
    }
]);
