starterControllers.controller('HomeCtrl', function ($scope, $location, EventFactory) {
  (function(){
    $scope.events = [];
  })()
  $scope.refreshEvents = function(){
    EventFactory.getAllEvents().then(function(response) {
      console.log(response);
      $scope.events = response.data;
    }, function(err){
      console.log(err);
    });
  }
  $scope.refreshEvents();

  });
