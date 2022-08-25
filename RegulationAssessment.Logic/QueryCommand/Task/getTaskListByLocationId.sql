SELECT
	"Task"."Id" AS "TaskId",
	"Law"."Title" AS "TaskTitle",
	"Task"."DueDate" AS "DueDate",
	"Task"."Process" AS "Process",
	CASE
		-- overdue
		WHEN "Task"."DueDate" < now()
			THEN 3
		-- today
		WHEN ("Task"."DueDate" = now()::date AND "Task"."DueDate" < now())
			THEN 2
		-- remain
		ELSE 1
	END AS "DatetimeStatus"
FROM "Task"
LEFT JOIN "Law" ON "Law"."Id" = "Task"."LawId"
WHERE "Task"."LocationId" = 'a2f78363-bb14-4419-a7f9-305295204eb3' AND "Process" != 6
ORDER BY "Process", "DatetimeStatus" DESC;