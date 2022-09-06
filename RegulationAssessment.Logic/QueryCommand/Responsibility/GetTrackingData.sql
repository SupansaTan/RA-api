SELECT
	"Task"."Id" AS "TaskId",
	"Law"."Title" AS "TaskTitle",
	"Location"."Name" AS "LocationName",
	"Responsibility"."DueDate" AS "DueDate",
	"Responsibility"."Status" AS "Status",
	CONCAT("Employee"."FirstName" , ' ' , "Employee"."LastName") AS "EmployeeName",
	CASE
		-- overdue
		WHEN "Responsibility"."DueDate" < now()
			THEN 3
		-- today
		WHEN ("Responsibility"."DueDate" = now()::date AND "Responsibility"."DueDate" >= now())
			THEN 2
		-- remain
		ELSE 1
	END AS "DatetimeStatus"
FROM "Location"
RIGHT JOIN "Task" ON "Task"."LocationId" = "Location"."Id"
INNER JOIN "Law" ON "Law"."Id" = "Task"."LawId"
INNER JOIN "TaskKeyAct" ON "TaskKeyAct"."TaskId" = "Task"."Id"
INNER JOIN "Responsibility" ON "Responsibility"."TaskKeyActId" = "TaskKeyAct"."Id"
INNER JOIN "Employee" ON "Employee"."Id" = "Responsibility"."EmpId"
WHERE "Location"."Id" = '_locationId';
