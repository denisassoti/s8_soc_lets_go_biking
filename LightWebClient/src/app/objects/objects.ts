// declare module namespace {
import { LatLngExpression } from 'leaflet';

    export interface Geometry {
      coordinates: number[][];
        type: string;
    }

    export interface Step {
        distance: number;
        duration: number;
        instruction: string;
        name: string;
        type: number;
        way_points: number[];
    }

    export interface Segment {
        distance: number;
        duration: number;
        steps: Step[];
    }

    export interface Summary {
        distance: number;
        duration: number;
    }

    export interface Properties {
        segments: Segment[];
        summary: Summary;
        way_points: number[];
    }

    export interface Feature {
        bbox: number[];
        geometry: Geometry;
        properties: Properties;
        type: string;
    }

    export interface Engine {
        build_date: Date;
        graph_date: Date;
        version: string;
    }

    export interface Query {
        coordinates: LatLngExpression[];
        format: string;
        profile: string;
    }

    export interface Metadata {
        attribution: string;
        engine: Engine;
        query: Query;
        service: string;
        timestamp: number;
    }

    export interface GetItineraireResult {
        bbox: number[];
        features: Feature[];
        // metadata: Metadata;
        type: string;
    }

    export interface RootObject {
        GetItineraireResult: GetItineraireResult;
    }
