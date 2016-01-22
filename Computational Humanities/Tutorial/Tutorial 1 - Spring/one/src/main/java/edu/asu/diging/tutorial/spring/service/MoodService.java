package edu.asu.diging.tutorial.spring.service;

import java.util.Random;

import org.springframework.stereotype.Service;

import edu.asu.diging.tutorial.spring.domain.Mood;

@Service
public class MoodService implements MoodServiceInterface{

	public Mood getCurrentMood(){
		String[] moods = {"happy", "sad", "disgust"};
		String[] reasons = {"work done", "no long weekend", "they donot keep my word"};
		Random random = new Random();
		int index = random.nextInt(moods.length);
		return new Mood(moods[index], reasons[index]);
	}
}
