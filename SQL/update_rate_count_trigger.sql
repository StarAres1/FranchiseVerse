CREATE TRIGGER after_rate_insert
AFTER INSERT ON "rate"
FOR EACH ROW
EXECUTE FUNCTION update_rate_count_on_insert();