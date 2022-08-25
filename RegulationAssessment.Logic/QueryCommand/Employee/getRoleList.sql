SELECT
	"Role"."Name" as "RoleName",
	"Location"."Name" as "Location"
FROM "Duty"
INNER JOIN "Role" ON "Duty"."RoleId" = "Role"."Id"
INNER JOIN "Location" ON "Duty"."LocationId" = "Location"."Id"
WHERE "Duty"."EmpId" = '_employeeId';