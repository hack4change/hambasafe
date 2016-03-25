starterControllers.controller('SearchCtrl', function ($scope, $stateParams, EventService, $location) {
    //init
    (function(){
      console.log($stateParams.lat);
      console.log($stateParams.lng);
      console.log($stateParams.dist);

    })()
    $scope.eventType = ["Event Type"];
    $scope.typeSelected = $scope.eventType[0];
    $scope.selectedSearch = 0;
    if($stateParams.lat && $stateParams.lng &&$stateParams.dist){
      $scope.selectedSearch = 1;
    }
    $scope.eventsToList = []
    $scope.searchEvents = function(){
      var searchBy = $scope.selectedSearch;
      EventService.getAllEvents().then(function(response) {
        $scope.eventsToList = response.data;
        console.elog
        console.log(response);
      }, function(response){

      });
    }
    $scope.searchEvents();
    $scope.getTypes=function(){

      EventService.getEventTypes().then(function(response) {

        $scope.eventTypes = [];
        for(var i = 0; i < response.data.length; i++){
          $scope.eventTypes.push(response.data[i].Name);
        }
        console.log($scope.eventTypes)
      }, function(response){
        console.log("error");
        console.log(response);
      });
    }
       $scope.getTypes();

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
    $scope.filterResults = function(eventObject){
      if($scope.typeSelected == "Event Type"){
        return true;
      } else {
        if($scope.typeSelected == eventObject.EventType.Name){
          return true;
        } else {
          return false;
        }
      }
    }
    $scope.goMap = function(){
      $location.path('app/map');
    }
  });
