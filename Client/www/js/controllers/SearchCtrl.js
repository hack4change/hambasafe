starterControllers.controller('SearchCtrl', function ($scope, EventService, $state, $location) {
    //init
    (function(){
      $scope.eventType = ["Walk", "Run", "Cycle"];
      $scope.typeSelected = $scope.eventType[0];
      $scope.selectedSearch = 0;
      $scope.eventsToList = []
    })()
    $scope.searchEvents = function(){
      var searchBy = $scope.selectedSearch;
      EventService.getAllEvents().then(function(response) {
        console.log(response);
        $scope.eventsToList = response.data;
      }, function(err){

      });
    }
    $scope.searchEvents();

    $scope.toggleGroup = function(group){
      if ($scope.isGroupShown(group)) {
        $scope.shownGroup = null;
      } else {
        $scope.shownGroup = group;
      }
    };
    $scope.toggleSelection = function(selected, group) {
      $scope.typeSelected = selected;
      $scope.toggleGroup(group);
    };

    $scope.isGroupShown = function(type, group) {
      return $scope.shownGroup === group && $scope.typeSelected !== type;
    };
    $scope.isShown = function(type, group) {
      return $scope.shownGroup === group && $scope.typeSelected !== type;
    };
    $scope.setActiveSearch = function(selection){
      $scope.selectedSearch = selection;
    }
    $scope.activeSearch = function(selection){
      return $scope.selectedSearch === selection;
    }
    $scope.goMap = function(){
      $location.path('app/map');
    }
  });
