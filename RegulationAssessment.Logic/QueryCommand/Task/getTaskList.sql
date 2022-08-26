SELECT
	"Task"."Id" AS "TaskId",
	"Law"."Title" AS "TaskTitle",
	"Location"."Name" AS "LocationName",
	"Task"."DueDate" AS "DueDate",
	"Task"."Process" AS "Process",
	CASE
		-- overdue
		WHEN "Task"."DueDate" < now()
			THEN 3
		-- today
		WHEN ("Task"."DueDate" = now()::date AND "Task"."DueDate" >= now())
			THEN 2
		-- remain
		ELSE 1
	END AS "DatetimeStatus"
FROM "Task"
LEFT JOIN "Law" ON "Law"."Id" = "Task"."LawId"
LEFT JOIN "Location" ON "Location"."Id" = "Task"."LocationId"
WHERE "Task"."LocationId" = '_empLocationId' AND "Task"."DueDate" >= now()::date
ORDER BY "Task"."DueDate";