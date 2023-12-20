using ArraysAndDataStructures;

ArrayandDastastructures arrayandDastastructures=new ArrayandDastastructures();
ArrayandDastastructures.Courier[] couriers=arrayandDastastructures.InitializeCouriers();

int[] tracking = new int[5];
arrayandDastastructures.TrackParcelLocation(tracking);

arrayandDastastructures.FindNearestCourier(couriers, "LocationA");