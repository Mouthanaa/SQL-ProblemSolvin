



--problem 1

create view VehicleMasterDetails
as
select VehicleDetails.ID, VehicleDetails.MakeID, Makes.Make, VehicleDetails.ModelID, MakeModels.ModelName,
VehicleDetails.SubModelID, SubModels.SubModelName, VehicleDetails.BodyID, Bodies.BodyName, VehicleDetails.Vehicle_Display_Name
, VehicleDetails.Year, VehicleDetails.DriveTypeID, DriveTypes.DriveTypeName, VehicleDetails.Engine,
VehicleDetails.Engine_CC, VehicleDetails.Engine_Cylinders, VehicleDetails.FuelTypeID, FuelTypes.FuelTypeName,
VehicleDetails.NumDoors 

from 
VehicleDetails inner join FuelTypes on VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID inner join
Bodies on VehicleDetails.BodyID = Bodies.BodyID inner join 
Makes on VehicleDetails.MakeID = Makes.MakeID inner join 
MakeModels on Makes.MakeID = MakeModels.MakeID inner join
SubModels on MakeModels.ModelID = SubModels.ModelID  and VehicleDetails.SubModelID = SubModels.SubModelID inner join 
DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID;


select* from VehicleMasterDetails;


select* from VehicleDetails;

--problem 2


select* from VehicleMasterDetails 
where Year between 1950 and 2000;


--problem 3

select NumberOfVehicles = count(*) from VehicleDetails
where year between 1950 and 2000;



--problem 4

select Make, NumberOfVehicles = count(*) from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID
where year between 1950 and 2000

group by Make
order by NumberOfVehicles desc;



--problem 5

select Makes.Make , count(*) As NumberOfVehicles from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeId
where Year between 1950 and 2000

group by Makes.Make
Having count(*) > 12000
order by NumberOfVehicles desc;



select* from
(
select Makes.Make , count(*) As NumberOfVehicles from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeId
where Year between 1950 and 2000

group by Makes.Make
) R1-- بتقدر تعمل كمان inner join مع R1
where R1.NumberOfVehicles>12000
order by R1.NumberOfVehicles desc;

--problem 6

select *,TotalVehicles = (select count(*) from VehicleDetails) from
(
select Makes.Make, count(*) As NumberOfVehicles from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeId
where Year between 1950 and 2000

group by Makes.Make
) R1

order by R1.NumberOfVehicles desc;

--or


select Makes.Make, Count(*) As NumberOfVehicles , TotalVehicles = (select count(*) from VehicleDetails) from
VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeId
where Year between 1950 and 2000

group by Makes.Make
order by NumberOfVehicles desc



--problem 7


select Makes.Make, Count(*) As NumberOfVehicles , TotalVehicles = (select count(*) from VehicleDetails),
perc = CAST(COUNT(*) AS FLOAT)
    / (SELECT COUNT(*) FROM VehicleDetails) from


VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeId
where Year between 1950 and 2000

group by Makes.Make
order by NumberOfVehicles desc





--problem 8


select Makes.Make , FuelTypes.FuelTypeName , NumberOfVehicels = Count(*) from 
VehicleDetails inner join Makes on Makes.MakeID = VehicleDetails.MakeID 
inner join FuelTypes on (VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID)
where Year between 1950 and 2000
group by Makes.Make, FuelTypes.FuelTypeName
order by Makes.Make;



--problem 9

select VehicleDetails.*,FuelTypes.FuelTypeName from VehicleDetails inner join FuelTypes on VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
where FuelTypes.FuelTypeName = N'GAS';



--problem 10

select distinct Makes.Make, FuelTypes.FuelTypeName from 
VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID 
inner join FuelTypes on VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
where FuelTypeName = N'Gas'



--problem 11

select TotalMakesOnGas = count(*) from
(
select distinct Makes.Make, FuelTypes.FuelTypeName from 
VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID 
inner join FuelTypes on VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
where FuelTypeName = N'Gas'
)R1;



--problem 12

select Makes.Make , NumberOfVehicles = Count(*) from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID
group by Makes.Make
order by NumberOfVehicles desc;


--problem 13

select Makes.Make , NumberOfVehicles = Count(*) from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID
group by Makes.Make
Having Count(*) > 20000
order by NumberOfVehicles desc;

--or

select* from
(
select Makes.Make , NumberOfVehicles = Count(*) from VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID
group by Makes.Make
)R1
where NumberOfVehicles > 20000
order by NumberOfVehicles desc;


--problem 14

select Make from Makes 
where Make like 'B%'

SELECT        Makes.Make 
FROM            Makes
where Makes.Make like 'B%';


--problem 15

select Makes.Make from Makes
where Make like '%W';


--problem 16


select distinct Makes.Make, DriveTypes.DriveTypeName from 
VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID 
inner join DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
where DriveTypeName = 'FWD'

--or

SELECT        distinct Makes.Make, DriveTypes.DriveTypeName
FROM            DriveTypes INNER JOIN
                         VehicleDetails ON DriveTypes.DriveTypeID = VehicleDetails.DriveTypeID INNER JOIN
                         Makes ON VehicleDetails.MakeID = Makes.MakeID
Where DriveTypes.DriveTypeName ='FWD'



--problem 17

select count(*) As TotalMakes from
(
SELECT        distinct Makes.Make, DriveTypes.DriveTypeName
FROM            DriveTypes INNER JOIN
                         VehicleDetails ON DriveTypes.DriveTypeID = VehicleDetails.DriveTypeID INNER JOIN
                         Makes ON VehicleDetails.MakeID = Makes.MakeID
Where DriveTypes.DriveTypeName ='FWD'
)r1


--problem 18

SELECT         distinct Makes.Make, DriveTypes.DriveTypeName, TotalVehicles = Count(*)
FROM            DriveTypes INNER JOIN
                         VehicleDetails ON DriveTypes.DriveTypeID = VehicleDetails.DriveTypeID INNER JOIN
                         Makes ON VehicleDetails.MakeID = Makes.MakeID
                         group by Makes.Make , DriveTypes.DriveTypeName
                         order by Make asc , TotalVehicles desc;


--problem 19

SELECT distinct Makes.Make, DriveTypes.DriveTypeName, TotalVehicles = Count(*)
FROM            DriveTypes INNER JOIN
                         VehicleDetails ON DriveTypes.DriveTypeID = VehicleDetails.DriveTypeID INNER JOIN
                         Makes ON VehicleDetails.MakeID = Makes.MakeID
                         group by Makes.Make , DriveTypes.DriveTypeName
                         Having count(*) > 10000
                         order by Make asc , TotalVehicles desc;


--problem 20

select* from VehicleDetails
where NumDoors is null;


--problem 21
select count(*) As TotalWithNoSpecifiedDoors from VehicleDetails
where NumDoors is null;


--problem 22

select
(
CAST((select count(*) As TotalWithNoSpecifiedDoors from VehicleDetails
where NumDoors is null) As float)
/

cast((select count(*) from VehicleDetails) As float)
)R1



select 

(
		CAST(	(select count(*) as TotalWithNoSpecifiedDoors from VehicleDetails
		where NumDoors is Null) as float)


		/
	
	
		Cast( (select count(*) from VehicleDetails as TotalVehicles) as float)
	
	
	) as PercOfNoSpecifiedDoors


    --problem 23

    select distinct Makes.MakeID , Makes.Make, SubModels.SubModelName from
    VehicleDetails inner join Makes on VehicleDetails.MakeID = Makes.MakeID
    inner join SubModels on VehicleDetails.SubModelID = SubModels.SubModelID
    where SubModels.SubModelName = 'Elite';

SELECT distinct    VehicleDetails.MakeID, Makes.Make, SubModelName
FROM            VehicleDetails INNER JOIN
                         SubModels ON VehicleDetails.SubModelID = SubModels.SubModelID INNER JOIN
                         Makes ON VehicleDetails.MakeID = Makes.MakeID
	
	where SubModelName='Elite'



    --problem 24 

    select * from VehicleDetails
    where Engine_Liter_Display > 3 and NumDoors = 2;


--problem 25

    select Makes.Make, VehicleDetails.* from VehicleDetails
    inner join Makes on Makes.MakeID = VehicleDetails.MakeID
    where (VehicleDetails.Engine LIKE '%OHV%') AND (VehicleDetails.Engine_Cylinders = 4)



    --problem 26 

    select VehicleDetails.*, Bodies.BodyName from VehicleDetails 
    inner join Bodies on VehicleDetails.BodyID = Bodies.BodyID
    where (Bodies.BodyName = N'Sport Utility') And (Year > 2020)

  
  --problem 27


  select VehicleDetails.*, Bodies.BodyName from VehicleDetails 
    inner join Bodies on VehicleDetails.BodyID = Bodies.BodyID
    where Bodies.BodyName in ('Coupe','Hatchback','Sedan');


--problem 28
    select VehicleDetails.*,Bodies.BodyName from VehicleDetails 
    inner join Bodies on VehicleDetails.BodyID = Bodies.BodyID
    where Bodies.BodyName in ('Coupe','Hatchback','Sedan') And  Year in ( 2008,2020,2021);



--problem 29

    select ReturnFound = 1  
    where Exists (select Top 1 * from VehicleDetails where Year = 1950);


--problem 30

    select Vehicle_Display_Name, NumDoors, DoorDescription =
    Case
    when NumDoors = 0 Then 'Zero Doors'
    when NumDoors = 1 Then 'One Doors'
    when NumDoors = 2 Then 'Two Doors'
    when NumDoors = 3 Then 'Third Doors'
    when NumDoors = 4 Then 'For Doors'
    when NumDoors = 5 Then 'Five Doors'
    when NumDoors = 6 Then 'Sex Doors'
    when NumDoors = 8 Then 'eight Doors'
    when NumDoors is null Then 'Not Set'

    else 'Unknown'
    End
    from VehicleDetails

   --problem 31

   select VehicleDetails.Vehicle_Display_Name, Year, Age = Year(GetDate()) - VehicleDetails.Year from VehicleDetails
   Order by Age Desc;



--problem 32

   select VehicleDetails.Vehicle_Display_Name, Year, Age = Year(GetDate()) - VehicleDetails.Year from VehicleDetails
   where Year(GetDate()) - VehicleDetails.Year between 15 and 25
   Order by Age Desc;

--or

   select* from
(
    Select VehicleDetails.Vehicle_Display_Name, Year, Age= YEAR(GetDate()) - VehicleDetails.year

    from VehicleDetails
) R1

Where Age between 15 and 25



--problem 33

select MinimumEngine_CC=Min(Engine_CC), MaximumEngine_CC = MAX(Engine_CC), Average_CC = Avg(Engine_CC)    from VehicleDetails;




--problem 34


select VehicleDetails.Vehicle_Display_Name from VehicleDetails
where Engine_CC = (select Min(VehicleDetails.Engine_CC) from VehicleDetails);




--problem 35

select VehicleDetails.Vehicle_Display_Name from VehicleDetails
where Engine_CC = (select MAX(Engine_CC) from VehicleDetails);



--problem 36



select VehicleDetails.Vehicle_Display_Name from VehicleDetails
where Engine_CC < (select AVG(Engine_CC) from VehicleDetails)


--problem 37

select count(*) As TotalVehiclesAbovAverage from VehicleDetails
where Engine_CC > (select Avg(Engine_CC) from VehicleDetails);

--or

select Count(*) as NumberOfVehiclesAboveAverageEngineCC from
(

    Select ID, VehicleDetails.Vehicle_Display_Name from VehicleDetails

    where Engine_CC > ( select Avg(Engine_CC) as MinEngineCC  from VehicleDetails )

) R1


--problem 38

select distinct Engine_CC from VehicleDetails
order by Engine_CC Desc;


--problem 39


Select distinct top 3 Engine_CC from VehicleDetails
	Order By Engine_CC Desc


--problem40

select VehicleDetails.Vehicle_Display_Name from VehicleDetails
where Engine_CC in 
(Select  distinct top 3 Engine_CC from VehicleDetails
	Order By Engine_CC Desc);


--problem 41

select distinct Makes.Make from VehicleDetails 
inner join Makes on Makes.MakeID = VehicleDetails.MakeID
where VehicleDetails.Engine_CC in 
(Select  distinct top 3 Engine_CC from VehicleDetails
	Order By Engine_CC Desc)
    

    --or
    SELECT        distinct Makes.Make
FROM            VehicleDetails INNER JOIN
                         Makes ON VehicleDetails.MakeID = Makes.MakeID
WHERE        (VehicleDetails.Engine_CC IN
                             (SELECT DISTINCT TOP (3) Engine_CC
                               FROM            VehicleDetails 
                               ORDER BY Engine_CC DESC)
							 )


--problem 42
select Engine_CC , Tax =

Case

when Engine_CC between 0 and 1000 then 100
WHEN Engine_CC between 1001 and 2000 THEN 200
WHEN Engine_CC between 2001 and 4000 THEN 300
WHEN Engine_CC between 4001 and 6000 THEN 400
WHEN Engine_CC between 6001 and 8000 THEN 500
WHEN Engine_CC > 8000 THEN 600
Else 0
end

from (select Distinct Engine_CC from VehicleDetails)R1



--problem 43


select Makes.Make , Sum(VehicleDetails.NumDoors) As TotalNumberOfDoors from 
VehicleDetails inner join Makes on Makes.MakeID = VehicleDetails.MakeID
group by Makes.Make
--Having Sum(VehicleDetails.NumDoors) is not Null
order by TotalNumberOfDoors desc;



--problem 44

select Makes.Make , Sum(VehicleDetails.NumDoors) As TotalNumberOfDoors from 
VehicleDetails inner join Makes on Makes.MakeID = VehicleDetails.MakeID
group by Makes.Make
Having Makes.Make = 'Ford'
order by TotalNumberOfDoors desc;


--problem 45

select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
order by NumberOfMake desc



--problem 46


select distinct top 3 *   from 
(
select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make

)R1
order by NumberOfMake desc;

--or
select top 3 Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
order by NumberOfMake desc


--problem 47

select MAX(NumberOfMake) As  HighestNumberOfModels from
(
select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
)R1



--problem 48

select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
Having Count(*) = (select MAX(NumberOfMake) As  HighestNumberOfModels from
(
select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group By Make

)R1)




--problem 49


select Min(NumberOfMake) As  MinimumNumberOfModels from
(
select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
)R1

--or
select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
Having Count(*) = (select Min(NumberOfMake) As  HighestNumberOfModels from
(
select Makes.Make, Count(*) As NumberOfMake from 
Makes inner join MakeModels on Makes.MakeID = MakeModels.MakeID
group By Make

)R1)


--problem 50


--problem 51 
SELECT
    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS [L.D.LAppID],
    LicenseClasses.ClassName AS DriverClass,
    People.NationalNo,

    CONCAT(
        People.FirstName, ' ',
        People.SecondName, ' ',
        People.ThirdName, ' ',
        People.LastName
    ) AS FullName,

    Applications.ApplicationDate,

    SUM(
        CASE
            WHEN Tests.TestResult = 1 THEN 1
            ELSE 0
        END
    ) AS PassedTests,

    CASE
        WHEN Applications.ApplicationStatus = 1 THEN 'New'
        WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'
        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'
        ELSE 'Unknown'
    END AS ApplicationStatus

FROM Applications

INNER JOIN LocalDrivingLicenseApplications
    ON Applications.ApplicationID =
       LocalDrivingLicenseApplications.ApplicationID

INNER JOIN People
    ON Applications.ApplicantPersonID = People.PersonID

INNER JOIN LicenseClasses
    ON LocalDrivingLicenseApplications.LicenseClassID =
       LicenseClasses.LicenseClassID

LEFT JOIN TestAppointments
    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
       TestAppointments.LocalDrivingLicenseApplicationID

LEFT JOIN Tests
    ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID

GROUP BY
    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
    LicenseClasses.ClassName,
    People.NationalNo,
    People.FirstName,
    People.SecondName,
    People.ThirdName,
    People.LastName,
    Applications.ApplicationDate,
    Applications.ApplicationStatus;
	

select * from FuelTypes
order by newID();



