SELECT 
	CASE
		-- relevant
		WHEN "Notification"."Process" = 1
			THEN 'relevant'
		-- consistance
		WHEN "Notification"."Process" = 3
			THEN 'consistance'
		-- approve
		WHEN "Notification"."Process" = 2 OR "Notification"."Process" = 4
			THEN 'approve'
		-- follow-up
		ELSE 'follow-up'
	END AS "type",
	CASE
		-- relevant
		WHEN "Notification"."Process" = 1
			THEN 'ประเมินความเกี่ยวข้อง'
		-- consistance
		WHEN "Notification"."Process" = 3
			THEN 'ประเมินความสอดคล้อง'
		-- approve
		WHEN "Notification"."Process" = 2 OR "Notification"."Process" = 4
			THEN 'รออนุมัติ'
		-- follow-up
		ELSE 'รอปฏิบัติให้สอดคล้อง'
	END AS "title",
	"Law"."Title" AS "content",
	"Notification"."NotifyDate" AS "time",
	"Notification"."Read" AS "readStatus"
FROM "Notification"
INNER JOIN "Task" ON "Task"."Id" = "Notification"."TaskId"
INNER JOIN "Law" ON "Law"."Id" = "Task"."LawId"
WHERE "Notification"."EmpId" = '_employeeId'
ORDER BY "Notification"."NotifyDate" DESC;
