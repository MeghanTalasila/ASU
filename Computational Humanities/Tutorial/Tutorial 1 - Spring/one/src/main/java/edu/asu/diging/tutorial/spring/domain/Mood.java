package edu.asu.diging.tutorial.spring.domain;

public class Mood {

	private String feeling;
	private String reason;

	public String getReason() {
		return reason;
	}

	public void setReason(String reason) {
		this.reason = reason;
	}

	public String getFeeling() {
		return feeling;
	}

	public void setFeeling(String feeling) {
		this.feeling = feeling;
	}

	public Mood(String mood, String reason) {
		super();
		this.feeling = mood;
		this.reason = reason;
	}
	
	
}
