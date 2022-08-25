SELECT DISTINCT 
	"Location"."Id" AS "LocationId",
	"Location"."Name" AS "LocationName",
	"Business"."Type" AS "BusinessType"
FROM "Duty"
INNER JOIN "Location" ON "Location"."Id" = "Duty"."LocationId"
INNER JOIN "Business" ON "Business"."Id" = "Location"."BusinessId"
WHERE "Duty"."EmpId" = '_employeeId';
