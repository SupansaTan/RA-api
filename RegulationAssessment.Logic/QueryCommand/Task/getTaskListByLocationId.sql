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
		WHEN ("Task"."DueDate" = now()::date AND "Task"."DueDate" >= now())
			THEN 2
		-- remain
		ELSE 1
	END AS "DatetimeStatus"
FROM "Task"
LEFT JOIN "Law" ON "Law"."Id" = "Task"."LawId"
WHERE 
	"Task"."LocationId" = '_locationId'
	AND "Process" != 7

	-- search by keywords 
	AND LOWER("Law"."Title") LIKE ALL(string_to_array('_keyword', ' '))
ORDER BY "Process", "DatetimeStatus" DESC;