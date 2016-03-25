starterControllers.controller('MapCtrl', function ($scope, EventService, $state, $compile, $ionicLoading, $location) {
  (function(){
    $scope.sliderDistance = 10;
  })()
  $scope.loading = $ionicLoading.show({
    content: 'Getting current location...',
    showBackdrop: false
  });

  $scope.searchByLocation = function(){
    console.log("Hey");
    if(!!$scope.gCoords && !!$scope.sliderDistance){
      console.log($scope.sliderDistance);
      console.log($scope.gCoords.lat() + " " + $scope.gCoords.lng() );
      $location.path('app/search?lat='+$scope.gCoords.lat()+ "&lng"+$scope.gCoords.lng()+"&dist="+ $scope.sliderDistance);
    }
  }
  $scope.init = function() {


    var mapOptions = {
      zoom: 10,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"),
                                  mapOptions);

    //Marker + infowindow + angularjs compiled ng-click
    // var contentString = "<div><a ng-click='clickTest()'>Click me!</a>a></div>div>";
    // var compiled = $compile(contentString)($scope);

    // var infowindow = new google.maps.InfoWindow({
    //   content: compiled[0]
    // });



    $scope.map = map;
    navigator.geolocation.getCurrentPosition(function(pos) {
      console.log(pos);
      $scope.map.setCenter(new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude));
      $scope.gCoords = new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude);
      $scope.marker = new google.maps.Marker({
        position: $scope.gCoords,
        map: $scope.map,
        title: 'You!'
      });
      $scope.locationCircle = new google.maps.Circle({
        strokeColor: '#FF0000',
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: '#FF0000',
        fillOpacity: 0.35,
        map: $scope.map,
        center:  $scope.gCoords,
        radius: $scope.sliderDistance*1000
      });
      $ionicLoading.hide();
    }, function(error) {
      alert('Unable to get location: ' + error.message);
    });
  }
  $scope.$watch('sliderDistance', function (newValue, oldValue) {
    console.log($scope.map)
    if($scope.map && $scope.locationCircle) {
      $scope.locationCircle.setOptions({
        radius: $scope.sliderDistance*1000
      });
    }
    //do something
  });
});
