starterControllers.controller('HomeCtrl', function ($scope, $location, EventService) {
  (function(){
    $scope.events = [];
  })()
  $scope.refreshEvents = function(){
    EventService.getAllEvents().then(function(response) {
      console.log(response);
      $scope.events = response.data;
    }, function(err){
      console.log(err);
    });
  }
  $scope.refreshEvents();

  $scope.click = function(event) {
    if (event.EventDateTimeEnd < new Date()) {
      $location.path("app/rating")
    } else {
      $location.path("app/event-detail")
    }
  }
});
